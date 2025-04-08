import { CircularProgress } from '@mui/material';

export const LoadingSpinner = () => (
  <div className="fixed inset-0 flex items-center justify-center bg-black bg-opacity-30">
    <CircularProgress />
  </div>
);