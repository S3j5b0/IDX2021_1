import pymongo
from json import JSONEncoder
import json
import hashlib
import ast
import random

from pymongo.collection import ReturnDocument
from pymongo.cursor import Cursor 
class User:
  def __init__(self, hash, color, WeeklyKWHUsage, savedKHWFromLastWeek,yearlyKHWSpending,WeeklyPrice,savedFromLastWeek,yearlySpending):
    self.hash = hash
    self.color = color
    self.WeeklyKWHUsage = WeeklyKWHUsage
    self.savedKHWFromLastWeek = savedKHWFromLastWeek
    self.yearlyKHWSpending = yearlyKHWSpending
    self.WeeklyPrice = WeeklyPrice
    self.savedFromLastWeek = savedFromLastWeek
    self.yearlySpending = yearlySpending
client = pymongo.MongoClient() 
mydb = client["mydb"] 

def updateuservalues(hash, color,WeeklyKWHUsage ,
savedKHWFromLastWeek, yearlyKHWSpending, WeeklyPrice, savedFromLastWeek, yearlySpending):
    yearlyKHW = yearlyKHWSpending + random.randrange(-500, 500)
    weeklyKHW = (WeeklyKWHUsage)+random.randrange(-5,5)
    savedweeklyKHW = abs(WeeklyKWHUsage-weeklyKHW)

    yearlyspend = yearlyKHW * 2
    weeklyPrice = weeklyKHW * 2
    savedweekly = savedweeklyKHW * 2
    color = ""
    if weeklyKHW < 1300:
        color = "green"
    elif weeklyKHW > 1300 and weeklyKHW < 2100:
        color = "yellow"
    else:
        color = "red"
    return {
        'hash': hash,
        'color': color,
        'WeeklyKWHUsage': weeklyKHW,
        'savedKHWFromLastWeek': savedweeklyKHW,
        'yearlyKHWSpending': yearlyKHW,
        'WeeklyPrice': weeklyPrice,
        'savedFromLastWeek': savedweekly,
        'yearlySpending': yearlyspend
    }
#    return User(hash,name, email=email, color=color,WeeklyKWHUsage=weeklyKHW ,
#4savedKHWFromLastWeek=savedweeklyKHW, yearlyKHWSpending=yearlyKHW, WeeklyPrice=weeklyPrice, savedFromLastWeek=savedweekly, yearlySpending=yearlyspend)

#

def createnewUser(name, email):
    yearlyKHW = abs(random.randrange(800, 4000))
    weeklyKHW = abs((yearlyKHW/52)+random.randrange(-30,30))
    savedweeklyKHW = abs(random.randrange(-10,10))

    yearlyspend = yearlyKHW * 2
    weeklyPrice = weeklyKHW * 2
    savedweekly = savedweeklyKHW * 2
    color = ""
    if weeklyKHW < 30:
        color = "green"
    elif weeklyKHW > 30 and weeklyKHW < 50:
        color = "yellow"
    else:
        color = "red"

    nameEmail = name+email
    hash = hashlib.sha256( nameEmail.encode('utf-8')).hexdigest()
    return User(hash, color=color,WeeklyKWHUsage=weeklyKHW ,
savedKHWFromLastWeek=savedweeklyKHW, yearlyKHWSpending=yearlyKHW, WeeklyPrice=weeklyPrice, savedFromLastWeek=savedweekly, yearlySpending=yearlyspend)


#Generic insert function
def db_insert(col_name, data):
    
    mycol = mydb[col_name]    
    Insert = mycol.insert_one(data)
    
    if Insert == None:
        print("insert returns none ")
        return 0
    else:
         return Insert

#Generic query function
def db_query(col_name,query):
    mycol = mydb[col_name]
    if query != "":
        query = mycol.find_one(query,{'_id': False})
    else:
        query = mycol.find_one({})
    if query == None:
        print("....[INFO]...An empty query returned. Check your query")
        return 0
    else:
        return query
def db_update( hashquery):
    mycol = mydb["something"]
    cursor  = db_query(col_name = "something", query = {"hash": hashquery})
    if cursor == 0:
        return ""
    newusr = updateuservalues(**cursor)

    updated = mycol.find_one_and_update({'hash': hashquery}, {'$set': newusr },{'_id': False}, return_document=ReturnDocument.AFTER)

    return updated


def createUser(name, email):
    mystring = name + email
    b = bytes(mystring, 'utf-8')

    hass = hashlib.sha224(b).hexdigest()
    count = db_query(col_name = "something", query = {"hash": hass})
    if count == 0:
        u = vars(createnewUser(name, email))
        res = db_insert( data = u, col_name="something")
        if res != 0:
            del u['_id']
            return u
    else:
        return "{  \"error\":\"finderror\"}"

    