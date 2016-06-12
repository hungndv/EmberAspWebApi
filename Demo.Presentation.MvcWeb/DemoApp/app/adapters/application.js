import JSONAPIAdapter from 'ember-data/adapters/json-api';
import DS from 'ember-data';

export default JSONAPIAdapter.extend({
    host: 'http://localhost:11012',
    namespace: 'api',
    handleResponse: function(status, headers, payload){
        switch(status){
            //case 0:
            //    payload = {};
            //    payload.errors = [];
            //    payload.errors.push('Cannot connect to server.');
            //    return new DS.InvalidError(payload.errors);
            case 400:
                payload.errors = [];
                if (payload.modelState) {
                    for(var key in payload.modelState) {
                        payload.errors.push(payload.modelState[key][0]);
                    }
                }
                return new DS.InvalidError(payload.errors);
        }
  
        return this._super(...arguments);
    }
});
