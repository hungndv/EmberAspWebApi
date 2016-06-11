import Ember from 'ember';

export default Ember.Component.extend({
  
    //firstNameIsEmpty: Ember.computed.empty('firstName'),
  
    isButtonDisabled: Ember.computed('model.firstName', 'model.lastName', function() {
        return !this.get('model.firstName') || !this.get('model.lastName');
    }),
  
    actions: {
        ok: function() {
            this.sendAction('ok', this.$('.modal'));
        },
        cancel() {
            this.sendAction('cancel', this.$('.modal'));
        }
    },
    didInsertElement: function() {
        $('.modal').modal().on('hidden.bs.modal', () => {
            this.sendAction('close');
        });
    }
});
