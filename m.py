import hashlib 


mystring = "AskAsk@mail.dk"
b = bytes(mystring, 'utf-8')

m = hashlib.sha224(b).hexdigest()


print(m)