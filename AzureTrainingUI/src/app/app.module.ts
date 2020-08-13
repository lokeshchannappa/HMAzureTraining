import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UploadComponent } from './upload/upload.component';
import { HttpClientModule } from '@angular/common/http';
import { CosmosDBComponent } from './cosmos-db/cosmos-db.component';
import { AzureBlobComponent } from './azure-blob/azure-blob.component';
import { RedisComponent } from './redis/redis.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadComponent,
    CosmosDBComponent,
    AzureBlobComponent,
    RedisComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
