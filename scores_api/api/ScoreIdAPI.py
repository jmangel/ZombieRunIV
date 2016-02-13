from flask.ext.restful import marshal
from api.BaseAPI import BaseAPI

class ScoreIdAPI(BaseAPI):
  """Operations on scores database by score id."""

  def get(self, id):
    """Retrieves the score corresponding to id 'id'.

    Arguments:
    id: The id for which to match to a score.
      - passed in by the Flask-RESTful API Library
    """
    from models import Score
    self.get_args()
    score = self.query_scores(lambda q: q.filter(Score.id == id))

    if len(score) == 0:
      return {'message': 'Resource not found.'}, 404
    return {'score': marshal(score[0], Score.fields)}