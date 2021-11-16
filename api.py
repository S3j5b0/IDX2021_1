from flask import Flask, request
from flask_restful import Resource, Api, reqparse
import ast
import dbInterface
app = Flask(__name__)
api = Api(app)
class CreateUser(Resource):

    def post(self): 
        json_data = request.get_json(force=True)
        name = json_data['name']
        print(name)
        email = json_data['email']
        print(email)
        userdata = dbInterface.createUser(name, email)
        print(userdata)
        return userdata, 200
class updateUser(Resource):

    def post(self): 
        json_data = request.get_json(force=True)
        hash = json_data['hash']
        userdata = dbInterface.db_update(hash)

        return userdata, 200


api.add_resource(updateUser, '/updateuser')
api.add_resource(CreateUser, '/createuser')

if __name__ == '__main__':
    app.run(port=9999)