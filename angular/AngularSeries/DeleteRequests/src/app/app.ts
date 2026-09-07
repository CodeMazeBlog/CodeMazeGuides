import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { Menu } from './menu/menu';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
  imports: [RouterOutlet, Menu],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('AccountOwnerClient');
}
