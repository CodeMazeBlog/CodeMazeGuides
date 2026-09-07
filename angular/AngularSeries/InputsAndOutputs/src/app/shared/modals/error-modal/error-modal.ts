import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
  selector: 'app-error-modal',
  styleUrl: './error-modal.css',
  templateUrl: './error-modal.html',
})
export class ErrorModal {
  modalHeaderText = '';
  modalBodyText = '';
  okButtonText = '';

  readonly bsModalRef = inject(BsModalRef);
}
