import JSONSerializer from 'ember-data/serializers/json';

export default JSONSerializer.extend({
  serialize(snapshot, options) {
    var json = this._super(...arguments);

    //debugger;
    // json.data.attributes.cost = {
      // amount: json.data.attributes.amount,
      // currency: json.data.attributes.currency
    // };
    //json.student = json.data;
    //delete json.data;
    //delete json.data.attributes.currency;

    return json;
  },
//  normalizeResponse (store, primaryModelClass, payload, id, requestType) {
    //payload.data.attributes.amount = payload.data.attributes.cost.amount;
    //payload.data.attributes.currency = payload.data.attributes.cost.currency;

    //delete payload.data.attributes.cost;

	// payload = payload.map(function(item){
		// item.type = 'student';
	// });
    
    // payload = {data: payload};
    // return this._super(...arguments);
//  },
  normalizeFindAllResponse (store, primaryModelClass, payload, id, requestType) {
    payload = payload.map(function(item){
        item.type = 'student';
    });
    
    payload = {data: payload};
    return this._super(...arguments);
  },
  normalizeSaveResponse (store, primaryModelClass, payload, id, requestType) {
    payload = {data: payload};
    return this._super(...arguments);
  }
});