import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-cosmos-db',
  templateUrl: './cosmos-db.component.html',
  styleUrls: ['./cosmos-db.component.css']
})
export class CosmosDBComponent implements OnInit {

  constructor(private http: HttpClient) { }
  public items: any = {};

  ngOnInit(): void {
    this.http.get(environment.apiBaseUrl + 'item')
      .subscribe(data => {
        this.items = data;
      });
  }
}
