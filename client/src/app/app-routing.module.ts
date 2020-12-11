import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
  { path: '', redirectTo: 'user/login', pathMatch: 'full' },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent }
    ]
  },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'test-error', component: TestErrorComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: 'admin', component: AdminComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
