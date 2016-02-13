from flask.ext.restful import marshal
from api.BaseAPI import BaseAPI

class ScoreListAPI(BaseAPI):
  """Operations on global Score list."""

  def get(self):
    """Gets a list of all recorded high scores."""
    from models import Score
    self.get_args()

    return {'scores': [
      marshal(score, Score.fields) for score in self.query_scores()
    ]}

  def post(self):
    """
    Creates a new score entry according to request parameters.
    Operation: POST /scores
    Preconditions:
      - HTTP request contains field 'score', which is an integer
      - HTTP request contains field 'name', which is a string
    Postconditions:
      - Database contains a new row containing score described in HTTP request.
    """
    from database import db
    from models import Score
    self.get_args()

    score = Score(self.parsed_args['score'], self.parsed_args['name'])
    score.save()

    return {'score': marshal(score, Score.fields)}, 201