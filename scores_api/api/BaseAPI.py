from flask.ext.restful import Resource, reqparse, marshal

class BaseAPI(Resource):
  def __init__(self):
    self.reqparse = reqparse.RequestParser()
    self.reqparse.add_argument(
      'order_by', 
      type=str, 
      choices=['created','-created','score', '-score'],
      default='-score',
      location='args',
    )
    self.reqparse.add_argument(
      'limit', 
      type=int,
      default=10,
      location='args',
    )
    self.reqparse.add_argument(
      'name',
      type=str,
      location=['args', 'form', 'json', 'values'],
    )
    self.reqparse.add_argument(
      'score',
      type=int,
      location=['args', 'form', 'json', 'values'],
    )
    super(BaseAPI, self).__init__()

  def get_order_by(self, param):
    """Returns tuple of order_by field and boolean value 'is_desc', denoting whether or not the query 'prm' is for descending order.

    Keyword arguments:
    param -- A string with an optional '-' at index 0.
    """
    if len(param) == 0:
      return "", False
    ret = param
    is_desc = False 
    if param[0] is '-':
      ret = param[1:]
      is_desc = True
    return ret, is_desc

  def get_args(self):
    """Initializes class member 'parsed_args', which holds the arguments passed in from any given request.

    Contract: call this function before processing request arguments in any function.

    Precondition:
      - self.get_args has not been called during this request yet

    Postcondition:
      - self.parsed_args contains the arguments passed in with the request.
    """
    self.parsed_args = self.reqparse.parse_args()

  def query_scores(self, filter_func=None):
    """Fetches records from score database according to parameter 'filter_func', or all scores if 'filter_func' is not present.

    Arguments:
    filter_func: lambda (Model.query) -> Model.query
      - performs a narrowing operation on the base model query

    Precondition:
      - self.get_args has been called

    Postcondition:
      - A collection of scores has been returned
    """
    from models import Score

    order_by, desc = self.get_order_by(self.parsed_args['order_by'])
    scores = Score.query

    if filter_func:
      scores = filter_func(scores)

    try:
      if desc:
        scores = scores.order_by(getattr(Score, order_by).desc())
      else:
        scores = scores.order_by(getattr(Score, order_by))
    except:
      return []

    if self.parsed_args['limit'] <= 0:
      scores = scores.all()
    else:
      scores = scores.limit(self.parsed_args['limit']).all()
    return scores