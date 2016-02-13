from flask.ext.restful import marshal
from api.BaseAPI import BaseAPI

class ScoreAPI(BaseAPI):
  """Operations on scores database by score creator names."""

  def get(self, name):
    """Retrieves all scores with name 'name'

    Arguments:
    name: The name for which to find scores in a case-insensitive search.
      - passed in by Flask-RESTful API Library
    """
    from models import Score
    self.get_args()
    scores = self.query_scores(lambda q: q.filter(Score.name.ilike(name)))

    if len(scores) == 0:
      return {'message': 'Resource not found.'}, 404
    return {'scores': [
      marshal(score, Score.fields) for score in scores
    ]}