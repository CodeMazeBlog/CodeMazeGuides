export interface TfaSetupDto{
    email?: string;
    code?: string;
    isTfaEnabled?: boolean;
    authenticatorKey?: string;
    formattedKey?: string;
}