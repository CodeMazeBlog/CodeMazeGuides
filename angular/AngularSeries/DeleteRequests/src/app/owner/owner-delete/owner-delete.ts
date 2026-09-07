import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService, ModalOptions } from 'ngx-bootstrap/modal';

import { Owner } from '../../_interfaces/owner.model';
import { OwnerRepositoryService } from '../../shared/services/owner-repository.service';
import { SuccessModal } from '../../shared/modals/success-modal/success-modal';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
  imports: [DatePipe],
  selector: 'app-owner-delete',
  styleUrl: './owner-delete.css',
  templateUrl: './owner-delete.html',
})
export class OwnerDelete implements OnInit {
  owner!: Owner;
  bsModalRef?: BsModalRef;

  private repository = inject(OwnerRepositoryService);
  private router = inject(Router);
  private activeRoute = inject(ActivatedRoute);
  private modal = inject(BsModalService);

  ngOnInit(): void {
    this.getOwnerById();
  }

  private getOwnerById = () => {
    const ownerId: string = this.activeRoute.snapshot.params['id'];
    const apiUri: string = `api/owner/${ownerId}`;

    this.repository.getOwner(apiUri)
    .subscribe({
      next: (own: Owner) => this.owner = own
    })
  }

  deleteOwner = () => {
    const deleteUri: string = `api/owner/${this.owner.id}`;

    this.repository.deleteOwner(deleteUri)
    .subscribe({
      next: () => {
        const config: ModalOptions = {
          initialState: {
            modalHeaderText: 'Success Message',
            modalBodyText: `Owner deleted successfully`,
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
