import { ChangeDetectionStrategy, Component, signal } from '@angular/core';

import { Home } from './home/home';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
  imports: [Home],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('AccountOwnerClient');
}
