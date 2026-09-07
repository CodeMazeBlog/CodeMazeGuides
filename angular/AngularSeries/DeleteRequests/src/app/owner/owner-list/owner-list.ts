import { DatePipe } from '@angular/common';
import { ChangeDetectionStrategy, Component, OnInit, inject } from '@angular/core';
import { Router, RouterLink } from '@angular/router';

import { Owner } from '../../_interfaces/owner.model';
import { OwnerRepositoryService } from '../../shared/services/owner-repository.service';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
  imports: [DatePipe, RouterLink],
  selector: 'app-owner-list',
  styleUrl: './owner-list.css',
  templateUrl: './owner-list.html',
})
export class OwnerList implements OnInit {
  owners: Owner[] = [];

  private repository = inject(OwnerRepositoryService);
  private router = inject(Router);

  ngOnInit(): void {
    this.getAllOwners();
  }

  private getAllOwners = () => {
    const apiAddress: string = 'api/owner';
    this.repository.getOwners(apiAddress)
    .subscribe({
      next: (own: Owner[]) => this.owners = own
    })
  }

  public getOwnerDetails = (id: string) => {
    const detailsUrl: string = `/owner/details/${id}`;
    this.router.navigate([detailsUrl]);
  }

  public redirectToUpdatePage = (id: string) => {
    const updateUrl: string = `/owner/update/${id}`;
    this.router.navigate([updateUrl]);
  }

  public redirectToDeletePage = (id: string) => {
    const deleteUrl: string = `/owner/delete/${id}`;
    this.router.navigate([deleteUrl]);
  }

}
