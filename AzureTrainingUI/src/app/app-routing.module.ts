import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CosmosDBComponent } from './cosmos-db/cosmos-db.component';
import { AzureBlobComponent } from './azure-blob/azure-blob.component';
import { RedisComponent } from './redis/redis.component';


const routes: Routes = [
  { path: '', redirectTo: '/blob', pathMatch: 'full' },
  { path: 'blob', component: AzureBlobComponent },
  { path: 'cosmos', component: CosmosDBComponent },
  { path: 'redis', component: RedisComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
