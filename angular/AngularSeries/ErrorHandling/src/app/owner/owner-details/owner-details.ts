import { DatePipe } from '@angular/common';
import { Component, OnInit, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Owner } from '../../_interfaces/owner.model';
import { OwnerRepositoryService } from '../../shared/services/owner-repository.service';

@Component({
  imports: [DatePipe],
  selector: 'app-owner-details',
  styleUrl: './owner-details.css',
  templateUrl: './owner-details.html',
})
export class OwnerDetails implements OnInit {
  owner = signal<Owner | undefined>(undefined);

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
      next: (own: Owner) => this.owner.set(own)
    })
  }

}
