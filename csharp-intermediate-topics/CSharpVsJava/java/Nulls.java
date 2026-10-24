void main() {
    IO.println(findEmail(42).map(String::length).orElse(0));

    String email = findEmailOrNull(42);
    IO.println(email.length());
}

Optional<String> findEmail(int customerId) {
    return customerId == 1 ? Optional.of("ann@example.com") : Optional.empty();
}

String findEmailOrNull(int customerId) {
    return customerId == 1 ? "ann@example.com" : null;
}
