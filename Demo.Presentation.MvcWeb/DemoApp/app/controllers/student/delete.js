import Ember from 'ember';

export default Ember.Controller.extend({
    title: 'Delete Student',
    submitButtonText: 'Delete',
    isDelete: true,
    actions: {
        save(modal) {
            $.blockUI();
            this.model.deleteRecord();
            this.model.save()
                .then(response => {
                    modal.modal('hide');
                    toastr.success('success');
                    $.unblockUI();
                }).catch(response => {
                    student.rollbackAttributes();
                    toastr.error('error');
                    $.unblockUI();
                });
        },
        cancel(modal){
            this.model.rollbackAttributes();
            modal.modal('hide');
        }
    }
});
