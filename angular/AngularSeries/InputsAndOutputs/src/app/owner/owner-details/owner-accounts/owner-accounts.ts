import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, EventEmitter, Input, Output } from '@angular/core';

import { Account } from '../../../_interfaces/account.model';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
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
