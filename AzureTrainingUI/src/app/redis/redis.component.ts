import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-redis',
  templateUrl: './redis.component.html',
  styleUrls: ['./redis.component.css']
})
export class RedisComponent implements OnInit {


  constructor(private http: HttpClient) { }
  public response: any;
  public newKey = {
    key:"",
    value: ""
  }

  ngOnInit() {
    this.GetCache();
  }
public AddNewKeyValue(){
  this.http.post(environment.apiBaseUrl+'redis',this.newKey).subscribe(event => {
    this.GetCache();
  });
}

  public GetCache() {

    this.http.get(environment.apiBaseUrl+'redis').subscribe(event => {
        this.response = event;
      });
  }

  public DeleteByKey(key){
    this.http.delete(environment.apiBaseUrl+'redis/'+key).subscribe(event => {
      this.GetCache();
    });
  }

  public EditByKey(item){
    this.newKey = item;
  }
}
