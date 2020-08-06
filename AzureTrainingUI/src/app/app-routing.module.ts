import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CosmosDBComponent } from './cosmos-db/cosmos-db.component';
import { AzureBlobComponent } from './azure-blob/azure-blob.component';


const routes: Routes = [
  { path: '', redirectTo: '/blob', pathMatch: 'full' },
  { path: 'blob', component: AzureBlobComponent },
  { path: 'cosmos', component: CosmosDBComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
