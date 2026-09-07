import { Component, EventEmitter, inject } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-success-modal',
  styleUrl: './success-modal.css',
  templateUrl: './success-modal.html',
})
export class SuccessModal {
  modalHeaderText = '';
  modalBodyText = '';
  okButtonText = '';
  redirectOnOk: EventEmitter<void> = new EventEmitter();

  private bsModalRef = inject(BsModalRef);

  onOkClicked = () => {
    this.redirectOnOk.emit();
    this.bsModalRef.hide();
  }

}
