import { Component } from '@angular/core';

@Component({
  selector: 'app-internal-server',
  styleUrl: './internal-server.css',
  templateUrl: './internal-server.html',
})
export class InternalServer {
  errorMessage = '500 SERVER ERROR, CONTACT ADMINISTRATOR!!!!';
}
