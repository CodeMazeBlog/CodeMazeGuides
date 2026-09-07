import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { BsDatepickerDirective, BsDatepickerInputDirective } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';

import { Owner } from '../../_interfaces/owner.model';
import { OwnerForCreation } from '../../_interfaces/ownerForCreation.model';
import { OwnerRepositoryService } from '../../shared/services/owner-repository.service';
import { SuccessModal } from '../../shared/modals/success-modal/success-modal';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
  imports: [ReactiveFormsModule, BsDatepickerDirective, BsDatepickerInputDirective],
  providers: [DatePipe],
  selector: 'app-owner-create',
  styleUrl: './owner-create.css',
  templateUrl: './owner-create.html',
})
export class OwnerCreate implements OnInit {
  ownerForm!: FormGroup;
  bsModalRef?: BsModalRef;

  private repository = inject(OwnerRepositoryService);
  private router = inject(Router);
  private datePipe = inject(DatePipe);
  private modal = inject(BsModalService);

  ngOnInit(): void {
    this.ownerForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      dateOfBirth: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });
  }

  validateControl = (controlName: string) => {
    const control = this.ownerForm.get(controlName);

    return control !== null && control.invalid && control.touched;
  }

  hasError = (controlName: string, errorName: string) => {
    return this.ownerForm.get(controlName)?.hasError(errorName) ?? false;
  }

  createOwner = (ownerFormValue: any) => {
    if (this.ownerForm.valid)
      this.executeOwnerCreation(ownerFormValue);
  }

  private executeOwnerCreation = (ownerFormValue: any) => {
    const owner: OwnerForCreation = {
      name: ownerFormValue.name,
      dateOfBirth: this.datePipe.transform(ownerFormValue.dateOfBirth, 'yyyy-MM-dd') ?? '',
      address: ownerFormValue.address
    }
    const apiUrl = 'api/owner';
    this.repository.createOwner(apiUrl, owner)
    .subscribe({
      next: (own: Owner) => {
        const config: ModalOptions = {
          initialState: {
            modalHeaderText: 'Success Message',
            modalBodyText: `Owner: ${own.name} created successfully`,
            okButtonText: 'OK'
          }
        };

        this.bsModalRef = this.modal.show(SuccessModal, config);
        this.bsModalRef.content?.redirectOnOk.subscribe(() => this.redirectToOwnerList());
      }
    })

  }

  redirectToOwnerList = () => {
    this.router.navigate(['/owner/list']);
  }

}
