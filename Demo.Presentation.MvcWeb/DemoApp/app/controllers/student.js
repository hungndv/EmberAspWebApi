import Ember from 'ember';

export default Ember.Controller.extend({
    init(){
        this.set('selection', 'byFirstName');
    },
    selectedNumberChanged: Ember.observer('selection', function(){
        this.send('handleFilterEntry');
    }),
    actions: {
        handleFilterEntry(){
            var searchString = this.get('searchString');
            if (searchString) {
                $.blockUI();
                this.store.unloadAll('student');
                var criteria = this.get('selection') === 'byFirstName' ? {firstName: searchString} : {lastName: searchString};
                this.store.query('student', criteria).then(success => {
                    $.unblockUI();
                    return success;
                })
            }
        }
    }
});
