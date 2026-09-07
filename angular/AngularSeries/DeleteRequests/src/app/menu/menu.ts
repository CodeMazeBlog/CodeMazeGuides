import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { CollapseDirective } from 'ngx-bootstrap/collapse';

@Component({
  imports: [RouterLink, RouterLinkActive, CollapseDirective],
  selector: 'app-menu',
  styleUrl: './menu.css',
  templateUrl: './menu.html',
})
export class Menu {
  isExpanded = false;
}
