import { DatePipe } from '@angular/common';
import { Component, OnInit, inject, signal } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BsDatepickerDirective, BsDatepickerInputDirective } from 'ngx-bootstrap/datepicker';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';

import { Owner } from '../../_interfaces/owner.model';
import { OwnerForUpdate } from '../../_interfaces/ownerForUpdate.model';
import { OwnerRepositoryService } from '../../shared/services/owner-repository.service';
import { SuccessModal } from '../../shared/modals/success-modal/success-modal';

@Component({
  imports: [ReactiveFormsModule, BsDatepickerDirective, BsDatepickerInputDirective],
  providers: [DatePipe],
  selector: 'app-owner-update',
  styleUrl: './owner-update.css',
  templateUrl: './owner-update.html',
})
export class OwnerUpdate implements OnInit {
  owner = signal<Owner | undefined>(undefined);
  ownerForm!: FormGroup;
  bsModalRef?: BsModalRef;

  private repository = inject(OwnerRepositoryService);
  private router = inject(Router);
  private activeRoute = inject(ActivatedRoute);
  private datePipe = inject(DatePipe);
  private modal = inject(BsModalService);

  ngOnInit(): void {
    this.ownerForm = new FormGroup({
      name: new FormControl('', [Validators.required, Validators.maxLength(60)]),
      dateOfBirth: new FormControl('', [Validators.required]),
      address: new FormControl('', [Validators.required, Validators.maxLength(100)])
    });

    this.getOwnerById();
  }

  private getOwnerById = () => {
    const ownerId: string = this.activeRoute.snapshot.params['id'];
    const ownerByIdUri: string = `api/owner/${ownerId}`;

    this.repository.getOwner(ownerByIdUri)
    .subscribe({
      next: (own: Owner) => {
        const owner: Owner = { ...own,
          dateOfBirth: new Date(own.dateOfBirth)
        };

        this.owner.set(owner);
        this.ownerForm.patchValue(owner);
      }
    })
  }

  validateControl = (controlName: string) => {
    const control = this.ownerForm.get(controlName);

    return control !== null && control.invalid && control.touched;
  }

  hasError = (controlName: string, errorName: string) => {
    return this.ownerForm.get(controlName)?.hasError(errorName) ?? false;
  }

  public updateOwner = (ownerFormValue: any) => {
    if (this.ownerForm.valid)
      this.executeOwnerUpdate(ownerFormValue);
  }

  private executeOwnerUpdate = (ownerFormValue: any) => {
    const ownerForUpd: OwnerForUpdate = {
      name: ownerFormValue.name,
      dateOfBirth: this.datePipe.transform(ownerFormValue.dateOfBirth, 'yyyy-MM-dd') ?? '',
      address: ownerFormValue.address
    }

    const apiUri: string = `api/owner/${this.owner()?.id}`;

    this.repository.updateOwner(apiUri, ownerForUpd)
    .subscribe({
      next: () => {
        const config: ModalOptions = {
          initialState: {
            modalHeaderText: 'Success Message',
            modalBodyText: 'Owner updated successfully',
            okButtonText: 'OK'
          }
        };

        this.bsModalRef = this.modal.show(SuccessModal, config);
        this.bsModalRef.content?.redirectOnOk.subscribe(() => this.redirectToOwnerList());
      }
    })
  }

  public redirectToOwnerList = () => {
    this.router.navigate(['/owner/list']);
  }

}
