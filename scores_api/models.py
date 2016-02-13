#!/usr/bin/env python
from datetime import datetime
from database import db
from flask.ext.restful import fields

class Score(db.Model):
    __tablename__ = 'scores'

    id = db.Column(db.Integer, primary_key=True, autoincrement=True)
    score = db.Column(db.Integer, index=True)
    name = db.Column(db.String(10), index=True)
    created = db.Column(db.DateTime)

    fields = {
        'name': fields.String,
        'score': fields.Integer,
        'created': fields.DateTime,
        'uri': fields.Url('scoreid')
    }

    def __init__(self,score,name):
        self.score = score
        self.name = name
        self.created = datetime.now()
        
    def __repr__(self):
        """String representation of this Score object"""
        return '%s - %d' % (self.name, self.score)

    def save(self):
        """
        Operation: model.save()
        Preconditions: 
            - Model has been properly created and instantiated
        Postconditions: 
            - Database contains a row with new model contents
        """
        db.session.add(self)
        db.session.commit()

    def json(self):
        return {
            "id": self.id,
            "score": self.score,
            "name": self.name,
            "created": self.created
        }