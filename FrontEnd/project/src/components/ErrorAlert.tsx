import { Alert, AlertTitle, Snackbar } from '@mui/material';
import { ValidationError, BusinessError } from '../types/api';

interface ErrorAlertProps {
  error: ValidationError | BusinessError | null;
  onClose: () => void;
}

export const ErrorAlert = ({ error, onClose }: ErrorAlertProps) => {
  if (!error) return null;

  const isValidationError = 'errors' in error;

  return (
    <Snackbar open={true} autoHideDuration={6000} onClose={onClose}>
      <Alert severity="error" onClose={onClose}>
        <AlertTitle>{error.title}</AlertTitle>
        {isValidationError ? (
          <ul className="list-disc pl-4">
            {error.errors.map((err, index) => (
              <li key={index}>
                {err.property}: {err.errors.join(', ')}
              </li>
            ))}
          </ul>
        ) : (
          error.detail
        )}
      </Alert>
    </Snackbar>
  );
};