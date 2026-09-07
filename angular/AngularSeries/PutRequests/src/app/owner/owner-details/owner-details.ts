import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Account } from '../../_interfaces/account.model';
import { Owner } from '../../_interfaces/owner.model';
import { OwnerRepositoryService } from '../../shared/services/owner-repository.service';
import { Append } from '../../shared/directives/append';
import { OwnerAccounts } from './owner-accounts/owner-accounts';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
  imports: [DatePipe, Append, OwnerAccounts],
  selector: 'app-owner-details',
  styleUrl: './owner-details.css',
  templateUrl: './owner-details.html',
})
export class OwnerDetails implements OnInit {
  owner!: Owner;

  private repository = inject(OwnerRepositoryService);
  private activeRoute = inject(ActivatedRoute);

  ngOnInit() {
    this.getOwnerDetails()
  }

  getOwnerDetails = () => {
    const id: string = this.activeRoute.snapshot.params['id'];
    const apiUrl: string = `api/owner/${id}/account`;

    this.repository.getOwner(apiUrl)
    .subscribe({
      next: (own: Owner) => this.owner = own
    })
  }

  printToConsole = (param: Account) => {
    console.log('Account parameter from the child component', param)
  }

}
