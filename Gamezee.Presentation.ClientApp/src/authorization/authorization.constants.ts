export const LoginActions = {
    Login: 'login',
    LoginCallback: 'login-callback',
    LoginFailed: 'login-failed',
    Profile: 'profile',
    Register: 'register'
  };

  export const LogoutActions = {
    LogoutCallback: 'logout-callback',
    Logout: 'logout',
    LoggedOut: 'logged-out'
  };

let applicationPaths: ApplicationPathsType = {
    Login: `${LoginActions.Login}`,
    LoginFailed: `${LoginActions.LoginFailed}`,
    LoginCallback: `${LoginActions.LoginCallback}`,
    Register: `${LoginActions.Register}`,
    Profile: `${LoginActions.Profile}`,
    LogOut: `${LogoutActions.Logout}`,
    LoggedOut: `${LogoutActions.LoggedOut}`,
  };

interface ApplicationPathsType {
    readonly Login: string;
    readonly LoginFailed: string;
    readonly LoginCallback: string;
    readonly Register: string;
    readonly Profile: string;
    readonly LogOut: string;
    readonly LoggedOut: string;
  }
  
  export const ApplicationPaths: ApplicationPathsType = applicationPaths;
  