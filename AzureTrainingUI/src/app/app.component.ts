import { Component } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.GetFiles();
  }

  public response: {};
  title = 'AzureTrainingUI';
  public uploadFinished = (event) => {
    this.response = event;
  }

  public GetFiles() {

    this.http.get('https://hmazuretrainingapi.azurewebsites.net/api/blob').subscribe(event => {
        this.response = event;
      });
  }
}
