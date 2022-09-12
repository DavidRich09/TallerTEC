import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {SharedModule} from "./shared/shared.module";

import { AppComponent } from './app.component';
import { Routes,RouterModule, RouterOutlet} from "@angular/router";
import { WorkerComponent } from './pages/worker/worker.component';
import { ClientComponent } from './pages/client/client.component';
import { CiteComponent } from './pages/cite/cite.component';
import { BillingComponent } from './pages/billing/billing.component';

const routes: Routes = [
  {path : 'worker', component: WorkerComponent},
  {path : "client", component: ClientComponent},
  {path : "cite", component: CiteComponent},
  {path : "billing", component: BillingComponent},
];

@NgModule({
  declarations: [
    AppComponent,
    WorkerComponent,
    ClientComponent,
    CiteComponent,
    BillingComponent,

  ],
    imports: [
        BrowserModule,
        RouterOutlet,
        SharedModule,
        RouterModule.forRoot(routes)
    ],
  exports: [RouterModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
