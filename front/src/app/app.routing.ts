import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { HomePage } from "./pages/home/home.page";
import { LojasComponent } from "./pages/lojas/lojas.component";

const appRoutes: Routes = [
  { path: "", redirectTo: "home", pathMatch: "full" },
  { path: "home", component: HomePage },
  { path: "lojas", component: LojasComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule],
})
export class Routing {}
