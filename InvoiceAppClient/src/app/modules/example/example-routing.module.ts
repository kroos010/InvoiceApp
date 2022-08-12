import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/core/guard/auth.guard';
import { ExampleComponent } from './page/example/example.component';

const routes: Routes = [
  {
    path: '',
    component: ExampleComponent, canActivate: [AuthGuard],
    children: [
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ExampleRoutingModule { }
