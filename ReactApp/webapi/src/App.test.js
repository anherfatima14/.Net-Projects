import { render, screen } from '@testing-library/react';
import App from './App';

test('renders App component without crashing', () => {
  render(<App />);
  const appElement = screen.getByText(/User Authentication and Registration/i);
  expect(appElement).toBeInTheDocument();
});
