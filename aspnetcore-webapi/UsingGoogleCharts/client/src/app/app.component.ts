import { Component, OnInit } from '@angular/core';
import { ChartType } from 'angular-google-charts';
import { LanguageService } from './_services/language.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  areaChart = ChartType.AreaChart;
  barChart = ChartType.BarChart;
  columnChart = ChartType.ColumnChart;
  lineChart = ChartType.LineChart;
  pieChart = ChartType.PieChart;

  data: any[] = [];

  columnNames = ['Language', 'Speakers (millions)'];

  width = 600;

  height = 400;

  donutOptions = {
    pieHole: 0.5
  }

  constructor(private languageService: LanguageService) {}

  ngOnInit(): void {
    this.languageService.GetLanguageStatistics().subscribe((result) => {
      this.data = [];

      for (let row in result) {
        this.data.push([
          result[row].name.toString(),
          result[row].speakersInMillions,
        ]);
      }
    });
  }
}
