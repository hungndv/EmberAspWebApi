import JSONAPIAdapter from 'ember-data/adapters/json-api';

export default JSONAPIAdapter.extend({
  host: 'http://localhost:11012',
  namespace: 'api',
  handleResponse: function(status, headers, payload){
    /*if(status === 400){
        payload.errors = [];
        if (payload.modelState) {
            for(var key in payload.modelState) {
              payload.errors.push(payload.modelState[key][0]);
            }
        }
        return new JSONAPIAdapter.InvalidError(payload.errors);
    }*/
    return this._super(...arguments);
  }
});
