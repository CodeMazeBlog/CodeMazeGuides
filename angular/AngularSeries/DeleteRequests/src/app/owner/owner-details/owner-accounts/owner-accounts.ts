import { DatePipe } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';

import { Account } from '../../../_interfaces/account.model';

@Component({
  imports: [DatePipe],
  selector: 'app-owner-accounts',
  styleUrl: './owner-accounts.css',
  templateUrl: './owner-accounts.html',
})
export class OwnerAccounts {
  @Input() accounts: Account[] = [];
  @Output() accountClick: EventEmitter<Account> = new EventEmitter();

  onAccountClicked = (account: Account) => {
    this.accountClick.emit(account);
  }

}
