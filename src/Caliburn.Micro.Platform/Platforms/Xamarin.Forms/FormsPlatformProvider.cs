﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Caliburn.Micro
{
    /// <summary>
    /// A <see cref="IPlatformProvider"/> implementation for the Xamarin.Forms platfrom.
    /// </summary>
    public class FormsPlatformProvider : IPlatformProvider
    {
        /// <summary>
        /// Creates an instance of <see cref="FormsPlatformProvider"/>.
        /// </summary>
        /// <param name="platformProvider">The existing platform provider (from the host platform) to encapsulate</param>
        public FormsPlatformProvider(IPlatformProvider platformProvider) {
            this.platformProvider = platformProvider;
        }

        private readonly IPlatformProvider platformProvider;

        /// <inheritdoc />
        public virtual bool InDesignMode => platformProvider.InDesignMode;

        /// <inheritdoc />
        public virtual void BeginOnUIThread(System.Action action) => platformProvider.BeginOnUIThread(action);

        /// <inheritdoc />
        public virtual Task OnUIThreadAsync(System.Action action) => platformProvider.OnUIThreadAsync(action);

        /// <inheritdoc />
        public virtual void OnUIThread(System.Action action) => platformProvider.OnUIThread(action);

        /// <inheritdoc />
        public virtual object GetFirstNonGeneratedView(object view) => platformProvider.GetFirstNonGeneratedView(view);

        /// <inheritdoc />
        public virtual void ExecuteOnFirstLoad(object view, Action<object> handler) {

            var page = view as Page;

            if (page != null) {
                EventHandler appearing = null;

                appearing = (s, e) => {

                    page.Appearing -= appearing;

                    handler(view);
                };

                page.Appearing += appearing;

                return;
            }

            platformProvider.ExecuteOnFirstLoad(view, handler);
        }

        /// <inheritdoc />
        public virtual void ExecuteOnLayoutUpdated(object view, Action<object> handler) => platformProvider.ExecuteOnLayoutUpdated(view, handler);

        /// <inheritdoc />
        public virtual Func<CancellationToken, Task> GetViewCloseAction(object viewModel, ICollection<object> views, bool? dialogResult) => platformProvider.GetViewCloseAction(viewModel, views, dialogResult);
    }
}
