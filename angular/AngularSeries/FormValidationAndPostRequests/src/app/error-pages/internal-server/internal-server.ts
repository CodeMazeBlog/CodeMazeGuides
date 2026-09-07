import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  changeDetection: ChangeDetectionStrategy.Eager,
  selector: 'app-internal-server',
  styleUrl: './internal-server.css',
  templateUrl: './internal-server.html',
})
export class InternalServer {
  errorMessage = '500 SERVER ERROR, CONTACT ADMINISTRATOR!!!!';
}
