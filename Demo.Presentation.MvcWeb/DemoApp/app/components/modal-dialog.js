import Ember from 'ember';

export default Ember.Component.extend({
  
  //firstNameIsEmpty: Ember.computed.empty('firstName'),
  
  isButtonDisabled: Ember.computed('firstName', 'lastName', function() {
    return !this.get('firstName') || !this.get('lastName');
  }),
  
  actions: {
    ok: function() {
      //this.$('.modal').modal('hide');
      this.sendAction('ok');
    }
  },
  didInsertElement() {
    this.$('.modal').modal().on('hidden.bs.modal', function() {
      this.sendAction('close');
    }.bind(this));
  }
});
