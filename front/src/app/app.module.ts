import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { Routing } from "./app.routing";
import { EnderecoService } from "./services/endereco.service";
import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { HomePage } from "./pages/home/home.page";
import { HttpClientModule, HttpClient } from "@angular/common/http";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ng6-toastr-notifications";
import { FormsModule } from "@angular/forms";
import { ReactiveFormsModule } from "@angular/forms";
import { NgxMaskModule } from "ngx-mask";
import { LojasComponent } from "./pages/lojas/lojas.component";

@NgModule({
  declarations: [AppComponent, HomePage, LojasComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    AppRoutingModule,
    Routing,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMaskModule.forRoot(),
  ],
  providers: [HttpClient, EnderecoService],
  bootstrap: [AppComponent],
})
export class AppModule {}
