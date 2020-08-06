import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UploadComponent } from './upload/upload.component';
import { HttpClientModule } from '@angular/common/http';
import { CosmosDBComponent } from './cosmos-db/cosmos-db.component';
import { AzureBlobComponent } from './azure-blob/azure-blob.component';

@NgModule({
  declarations: [
    AppComponent,
    UploadComponent,
    CosmosDBComponent,
    AzureBlobComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
