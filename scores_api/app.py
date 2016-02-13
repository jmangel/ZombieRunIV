#!/usr/bin/env python
from flask import Flask, jsonify, request
from flask.ext.restful import Api, Resource, abort, reqparse, marshal
from api.ScoreAPI import ScoreAPI
from api.ScoreIdAPI import ScoreIdAPI
from api.ScoreListAPI import ScoreListAPI
from config import *

app = Flask(__name__)
# app.config.from_object(ProdConfig)
app.config.from_object(Config)
api = Api(app)

# while migrating
# from models.Score import Score 

@app.route('/')
def index():
  return "Hello World!"

api.add_resource(ScoreListAPI, "/scores/", endpoint="scores")
api.add_resource(ScoreAPI, "/scores/<string:name>", endpoint="score")
api.add_resource(ScoreIdAPI, "/scores/id/<int:id>", endpoint="scoreid")

if __name__ == '__main__':
  port = int(os.environ.get("PORT", 5000))
  app.run(host='0.0.0.0', port=port)
