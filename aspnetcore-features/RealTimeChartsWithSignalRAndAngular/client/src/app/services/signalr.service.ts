import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as signalR from "@microsoft/signalr"
import { ChartModel } from '../_interfaces/chartmodel.model';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {
  public data: ChartModel[];
  public connectionId: string;
  public broadcastedData: ChartModel[];

  constructor(private http: HttpClient) {}

  private hubConnection: signalR.HubConnection

  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('https://localhost:5001/chart')
                            .withAutomaticReconnect()
                            .configureLogging(signalR.LogLevel.Information)
                            .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .then(() => this.getConnectionId())
      .catch(err => console.log('Error while starting connection: ' + err))

    this.hubConnection.onreconnecting(err => {
      console.log('Connection lost, reconnecting: ' + err);
    })

    this.hubConnection.onreconnected(connectionId => {
      this.connectionId = connectionId;

      this.http.get('https://localhost:5001/api/chart')
      .subscribe(res => {
        console.log(res);
      })
    })

    this.hubConnection.onclose(() => {
      console.log('Connection closed, a refresh is required');
    })
  }

  public addTransferChartDataListener = () => {
    this.hubConnection.on('transferchartdata', (data) => {
      this.data = data;
      console.log(data);
    });
  }

  private getConnectionId = () => {
    this.hubConnection.invoke('getconnectionid')
    .then((data) => {
      console.log(data);
      this.connectionId = data;
    });
  }

  public broadcastChartData = () => {
    const data = this.data.map(m => {
      const temp = {
        data: m.data,
        label: m.label
      }
      return temp;
    });

    this.hubConnection.invoke('broadcastchartdatatoclient', data, this.connectionId)
    .catch(err => console.error(err));
  }

  public addBroadcastChartDataListener = () => {
    this.hubConnection.on('broadcastchartdata', (data) => {
      this.broadcastedData = data;
    })
  }
}
