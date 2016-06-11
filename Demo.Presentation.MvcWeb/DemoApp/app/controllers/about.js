import Ember from 'ember';

export default Ember.Controller.extend({
    actions: {
        showModal1(){
            debugger;
            $('.modal').modal('show');
        }
    }
});
