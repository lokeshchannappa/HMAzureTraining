import { Component, OnInit } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-azure-blob',
  templateUrl: './azure-blob.component.html',
  styleUrls: ['./azure-blob.component.css']
})
export class AzureBlobComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.GetFiles();
  }

  public response: {};
  public uploadFinished = (event) => {
    this.response = event;
  }

  public GetFiles() {

    this.http.get(environment.apiBaseUrl+'blob').subscribe(event => {
        this.response = event;
      });
  }

}
