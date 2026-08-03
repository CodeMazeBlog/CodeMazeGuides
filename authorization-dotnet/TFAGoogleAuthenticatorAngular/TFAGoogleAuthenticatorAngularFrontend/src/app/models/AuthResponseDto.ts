export interface AuthResponseDto {
    isAuthSuccessful: boolean;
    isTfaEnabled: boolean;
    errorMessage: string;
    token: string;
}