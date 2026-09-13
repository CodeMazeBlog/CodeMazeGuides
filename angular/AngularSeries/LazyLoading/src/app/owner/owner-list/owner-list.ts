import { DatePipe } from '@angular/common';
import { Component, OnInit, inject, signal } from '@angular/core';

import { Owner } from '../../_interfaces/owner.model';
import { OwnerRepositoryService } from '../../shared/services/owner-repository.service';

@Component({
  imports: [DatePipe],
  selector: 'app-owner-list',
  styleUrl: './owner-list.css',
  templateUrl: './owner-list.html',
})
export class OwnerList implements OnInit {
  owners = signal<Owner[]>([]);

  private repository = inject(OwnerRepositoryService);

  ngOnInit(): void {
    this.getAllOwners();
  }

  private getAllOwners = () => {
    const apiAddress: string = 'api/owner';
    this.repository.getOwners(apiAddress)
    .subscribe(own => {
      this.owners.set(own);
    })
  }

}
