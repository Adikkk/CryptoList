import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UUID } from 'angular-uuid';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  private baseUrl: string;
  totalSitesCount: any;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    ) {
      this.baseUrl = baseUrl;
    }

  
  ngOnInit() {
    this.http.get<any>(this.baseUrl + 'api/dashboard'
    ).subscribe({
      next: data => {
        console.log(data);
        this.totalSitesCount = data.length;
      }
    });
    
  }

}
