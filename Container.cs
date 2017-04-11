using libunity.ioc;

class Container {
  public static void register(object o) {
    depend.register(o);
  }

  public static void injection(object o) {
    depend.injection(o);
  }

  private static dependencies depend = new dependencies();
}
